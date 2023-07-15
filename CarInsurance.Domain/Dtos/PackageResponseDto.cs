namespace CarInsurance.Domain.Dtos
{
    public class ResponsePackageDto<T>
    {
        public ResponsePackageDto() { }
        public string Message { get; set; }
        public T Result { get; set; }
        public object Errors { get; set; }
    }
}
