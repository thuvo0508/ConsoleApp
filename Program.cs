﻿var githubToken = "[token]";
var url = "[github_url]";
var path = @"..\..\..\Download\repo.zip";

using (var client = new System.Net.Http.HttpClient())
{
    var credentials = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}:", githubToken);
    credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(credentials));
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);
    var contents = client.GetByteArrayAsync(url).Result;
    System.IO.File.WriteAllBytes(path, contents);
    Console.WriteLine("Done!");
}