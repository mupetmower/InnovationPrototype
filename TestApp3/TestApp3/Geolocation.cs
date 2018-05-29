using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.CurrentActivity;
using Android.Widget;

namespace TestApp3
{
    class Geolocation
    {
        private TimeSpan LOCATOR_TIMEOUT = TimeSpan.FromMilliseconds(1000);
        private IGeolocator geolocator;

        public Geolocation() {
            Init();
        }

        /// <summary>
        /// Check to make sure Geolocation is supported, available, and enabled.
        /// </summary>
        /// <returns></returns>
        public bool CanUseGeolocation()
        {
            try
            {
                if (!CrossGeolocator.IsSupported)
                    throw new Exception("Geolocation is not suported.");

                if (!CrossGeolocator.Current.IsGeolocationAvailable)
                    throw new Exception("Geolocation is not available.");

                if (!CrossGeolocator.Current.IsGeolocationEnabled)
                    throw new Exception("Geolocation is not enabled.");

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            Init();
            return true;
        }

        public void Init()
        {
            geolocator = CrossGeolocator.Current;
            //geolocator.DesiredAccuracy = 50;
        }

        public async void GetPosition()
        {
            var position = await geolocator.GetPositionAsync(LOCATOR_TIMEOUT);

            PrintPosition(position, "In GetPosition()");
        }



        public async void PrintPosition(Position position, string title)
        {
            double lat = position.Latitude;
            double lon = position.Longitude;
            var timeStamp = position.Timestamp;
            string time = timeStamp.DateTime.ToString();

            double alt = position.Altitude;          

            double head = position.Heading;
            double speed = position.Speed;


            IEnumerable<Address> addresses = await geolocator.GetAddressesForPositionAsync(position);

            Address address = new Address();

            if (addresses != null && addresses.GetEnumerator().MoveNext())
                address = addresses.GetEnumerator().Current;

            foreach (Address a in addresses)
            {
                address = a;
            }

            string strAddress = String.Format("{0} {1}, {2}, {3} {4}", 
                address.SubThoroughfare, address.Thoroughfare, address.Locality, address.AdminArea, address.PostalCode);

            Console.WriteLine(title + "\n" + time + "\n" +
                String.Format("Lat: {0}, Lon: {1}, Altitude: {2}, Heading: {3}, Speed: {4}\n" +
                "Address: {5}\n" +
                "Address Lat: {6}, Address Lon: {7}",
                lat, lon, alt, head, speed, strAddress, address.Latitude, address.Longitude));
        }


        public async void RequestLocation()
        {
            try
            {
                //Checking location permission. If not granted, requests it.
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        Toast.MakeText(CrossCurrentActivity.Current.Activity, "Need location", duration: ToastLength.Short);
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    var position = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromMilliseconds(1000));
                    PrintPosition(position, "In RequestLocation()");
                }
                else if (status != PermissionStatus.Unknown)
                {
                    Toast.MakeText(CrossCurrentActivity.Current.Activity, "Location Denied", duration: ToastLength.Short);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex);
            }
        }

    }
}
