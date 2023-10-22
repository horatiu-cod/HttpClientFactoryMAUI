namespace MauiClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCallApiButtonClicked(object sender, EventArgs e)
        {
            //create the http client
            var httpClient = new HttpClientService().GetPlatformSpecificHttpClient();
            // switch if is android to https://10.0.2.2: 
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7297" : "https://localhost:7297";
            // get the response from get method of specific uri
            var response =  await httpClient.GetAsync($"{baseUrl}/WeatherForecast");
            // read and store the json string data of response
            var data = await response.Content.ReadAsStringAsync();
            apiResponse.Text = data;
        }
    }
}