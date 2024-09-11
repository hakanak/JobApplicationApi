namespace JobApplicationApi.Model
{
    public class ResultData<T>
    {
        public int Id { get; set; }
        public int number_result { get; set; }
        public T Data { get; set; }
        public bool successful { get; set; }
        public string message { get; set; }
    }
}
