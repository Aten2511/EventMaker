using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using EventMaker.Common;
using EventMaker.Converter;
using EventMaker.Model;
using EventMaker.Persistency;
using EventMaker.ViewModel;

namespace EventMaker.Handler
{
    public class EventHandler
    {
        public EventViewModel Events { get; set; }

       
        public EventHandler(EventViewModel events)
        {
            Events = events;
        }

        public  async void  CreateEvent()
        {
           
                Event e1 = new Event(Events.Id, Events.Name, Events.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(Events.Date, Events.Time), Events.Description);
                await Events.EventCatalogSingleton.Add(e1);
            

            //PersistencyService.SaveEventsAsJson(EventCatalogSingleton.Events);

        }


        public async void  DeleteEvent()
        {
         if (Events.SelectedEvent==null)
         {
                var message1 = new MessageDialog("Select an event please!");
                message1.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 0 });

                await message1.ShowAsync();


         }

         else
         {
                var message = new MessageDialog("Are you sure you want to delete the Event: " + Events.SelectedEvent.Name + " ?");
                message.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandlerDelete)));;
                message.Commands.Add(new UICommand("No", null));

                message.DefaultCommandIndex = 0;
                message.CancelCommandIndex = 1;
                await message.ShowAsync();

            }
            

        }

        private async void CommandInvokedHandlerDelete(IUICommand command)
        {
            await Events.EventCatalogSingleton.Remove(Events.SelectedEvent);
           //PersistencyService.SaveEventsAsJson(EventCatalogSingleton.Events);



        }

        //public async void EditEvent()
        //{
        //     //EventViewModel.EventHandler.EditEvent(EventViewModel.SelectedEvent);


        //    var message = new MessageDialog("Do you want to save changes ?");
        //    message.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandlerEdit)));
        //    message.Commands.Add(new UICommand("No", null));

        //    message.DefaultCommandIndex = 0;
        //    message.CancelCommandIndex = 1;
        //    await message.ShowAsync();

        //}

        //private void CommandInvokedHandlerEdit(IUICommand command)
        //{
        //    //EventViewModel.EventCatalogSingleton.Edit(EventViewModel.SelectedEvent, EventViewModel.Id, EventViewModel.Name, EventViewModel.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventViewModel.Date, EventViewModel.Time), EventViewModel.Description);
        //}
    }

    
}
