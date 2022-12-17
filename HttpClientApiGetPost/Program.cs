// HttpClient Sınıfı İle Apilere İstekte Bulunma

// KAYNAK: https://learn.microsoft.com/tr-tr/dotnet/api/system.net.http.httpclient?view=net-7.0

// API: https://jsonplaceholder.typicode.com/

using HttpClientApiGetPost;
using System.Net.Http.Json;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string url = "https://jsonplaceholder.typicode.com/todos";

HttpClient client = new HttpClient();

HttpResponseMessage cevap = await client.GetAsync(url);

#region Cevabı String Olarak Okuma
//string icerik = await cevap.Content.ReadAsStringAsync();
//Console.WriteLine(icerik); 
#endregion

List<Todo> todos = await cevap.Content.ReadFromJsonAsync<List<Todo>>();

foreach (var item in todos.Take(10))
{
    Console.WriteLine($"Id: {item.Id} Title: {item.Title}");
}

Console.WriteLine("...");

Console.WriteLine("--------------------------------");

url = "https://jsonplaceholder.typicode.com/posts";

CreatePost yeni = new CreatePost()
{
    UserId = 77,
    Title = "Bugün Cumartesi",
    Body = "Hava biraz kapalı ve ben de HttpClient sınıfının kullanımını öğreniyorum."
};

cevap = await client.PostAsJsonAsync(url, yeni);

Post olusan = await cevap.Content.ReadFromJsonAsync<Post>();

Console.WriteLine("SUNUCUDA OLUŞAN YAZIMIZ:");
Console.WriteLine("Id: " + olusan.Id);
Console.WriteLine("Kullanıcı Id: " + olusan.UserId);
Console.WriteLine("Başlık: " + olusan.Title);
Console.WriteLine("Gövde: " + olusan.Body);

Console.ReadKey();