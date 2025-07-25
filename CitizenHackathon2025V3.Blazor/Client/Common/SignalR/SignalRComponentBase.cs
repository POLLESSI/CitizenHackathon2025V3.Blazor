using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenHackathon2025V3.Blazor.Client.Common.SignalR
{
    public abstract class SignalRComponentBase<TModel> : ComponentBase, IAsyncDisposable
    {
    #nullable disable
        protected HubConnection hubConnection;

        public List<TModel> Items { get; private set; } = new();
        public List<TModel> VisibleItems { get; private set; } = new();

        protected int BatchSize { get; set; } = 10;
        protected int CurrentIndex { get; private set; } = 0;
        protected bool IsEndOfList => CurrentIndex >= Items.Count;

        protected bool IsLoading { get; private set; }
        protected string ErrorMessage { get; private set; }

        /// <summary>
        /// Will be triggered on each new item received via SignalR.
        /// </summary>
        [Parameter]
        public EventCallback<TModel> OnNewItem { get; set; }

        protected abstract string HubUrl { get; }
        protected abstract string HubEventName { get; }
        protected abstract Task<List<TModel>> LoadDataAsync();

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            try
            {
                Items = await LoadDataAsync();
                LoadNextPage();
                await InitializeHubConnection();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsLoading = false;
            }
        }

        /// <summary>
        /// Loads the next portion of items.
        /// </summary>
        protected void LoadNextPage()
        {
            if (IsEndOfList) return;

            var nextBatch = Items.Skip(CurrentIndex).Take(BatchSize).ToList();
            VisibleItems.AddRange(nextBatch);
            CurrentIndex += BatchSize;
            StateHasChanged();
        }

        private async Task InitializeHubConnection()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(HubUrl, options =>
                {
                    options.SkipNegotiation = true;
                    options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
                })
                .WithAutomaticReconnect()
                .Build();

            hubConnection.On<TModel>(HubEventName, async model =>
            {
                Items.Insert(0, model);
                VisibleItems.Insert(0, model);
                CurrentIndex++;

                await InvokeAsync(StateHasChanged);

                if (OnNewItem.HasDelegate)
                {
                    await OnNewItem.InvokeAsync(model);
                }
            });

            await hubConnection.StartAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (hubConnection != null)
            {
                await hubConnection.DisposeAsync();
            }
        }
        protected virtual Task OnNewItemReceived(TModel item)
        {
            return Task.CompletedTask;
        }
    }
}

















































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/