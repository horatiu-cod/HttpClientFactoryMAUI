namespace MauiClient
{
    public partial class MainPage : ContentPage
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MainPage(IHttpClientFactory httpClientFactory)
        {
            InitializeComponent();
            _httpClientFactory = httpClientFactory;
        }

        private async void OnCallApiButtonClicked(object sender, EventArgs e)
        {
            //create the http client
            var httpClient = _httpClientFactory.CreateClient("maui-to-api");
            // get the response from get method of specific uri
            var response =  await httpClient.GetAsync("/WeatherForecast");
            // read and store the json string data of response
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                apiResponse.Text = data;
            }
        }
    }
}