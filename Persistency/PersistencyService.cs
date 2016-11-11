using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using EventMaker.Common;
using EventMaker.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EventMaker.Persistency
{
    class PersistencyService
    {
        private static string fileName = "EventAsJson.dat";

        public static async Task SaveEventsAsJson(ObservableCollection<Event> events)
        {
            try
            {
                string stringEventsJson = JsonConvert.SerializeObject(events);
                await SerializeEventsFileAsync(stringEventsJson, fileName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("There is something wrong with saving");
            }
            
        }

        public static async Task SerializeEventsFileAsync(string stringEvent, string eventfilename)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(eventfilename,CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, stringEvent);
        }

        public static async Task<List<Event>> LoadEventsFromJson()
        {
            string eventsJsonString = await DeSerializeEventsFileAsync(fileName);
            if (eventsJsonString != null)
                return (List<Event>)JsonConvert.DeserializeObject(eventsJsonString, typeof(List<Event>));
            return null;
        }



        public static async Task<string> DeSerializeEventsFileAsync(String eventfilename)
        {
           try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(eventfilename);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {

                //MessageBox.Show("Events list can not be found!");
                return null;

            }

        }


    }
}
