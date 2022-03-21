using Newtonsoft.Json;
using Practice.Interface;
using Practice.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Practice.Service
{
    public class StudentWebService : IStudentService
    {

        public const string BASE_URL = "https://localhost:44350/api/";
        private readonly HttpClient m_client;

        public StudentWebService()
        {
            m_client = new HttpClient();
            m_client.BaseAddress = new Uri(BASE_URL);
        }

        public Student Add(Student student)
        {
            var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            var responseTask = m_client.PostAsync($"student",content);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var jsonResult = result.Content.ReadAsStringAsync();
                jsonResult.Wait();
                return JsonConvert.DeserializeObject<Student>(jsonResult.Result);
            }
            return new Student();
        }

        public List<string> GetAllClasses()
        {
            var responseTask = m_client.GetAsync($"student/getallclass");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var jsonResult = result.Content.ReadAsStringAsync();
                jsonResult.Wait();
                return JsonConvert.DeserializeObject<List<string>>(jsonResult.Result);
            }
            return new List<string>();
        }

        public void Remove(int studentId)
        {
            var responseTask = m_client.DeleteAsync($"student/{studentId}");
            responseTask.Wait();
      
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var jsonResult = result.Content.ReadAsStringAsync();
                jsonResult.Wait();
            }
        }

        public List<Student> SearchStudent(StudentSearchCriteria criteria)
        {
            var urlbuilder = new UriBuilder(BASE_URL + "student");
            urlbuilder.Query = string.Format("searchText={0}&studentClass={1}", criteria.SearchText, criteria.ClassName);

            var responseTask = m_client.GetAsync(urlbuilder.Uri);

            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var jsonResult = result.Content.ReadAsStringAsync();
                jsonResult.Wait();
                return JsonConvert.DeserializeObject<List<Student>>(jsonResult.Result);
            }

            return new List<Student>();
        }

        public Student Update(Student student)
        {
            var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            var responseTask = m_client.PutAsync($"student", content);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var jsonResult = result.Content.ReadAsStringAsync();
                jsonResult.Wait();
                return JsonConvert.DeserializeObject<Student>(jsonResult.Result);
            }
            return new Student();
        }
    }
}
