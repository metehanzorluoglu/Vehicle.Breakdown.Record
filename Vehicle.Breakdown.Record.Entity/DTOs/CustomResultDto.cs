using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VehicleBreakdownRecord.Entity.DTOs
{
    /*
     * [x] Create Static Factory Method for All Result
     */
    public class CustomResultDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public static CustomResultDto<T> Success(T data,int statusCode)
        {
            return new CustomResultDto<T> { Data = data, StatusCode = statusCode};
        }
        public static CustomResultDto<T> Success( int statusCode)
        {
            return new CustomResultDto<T> {  StatusCode = statusCode};
        }

        public static CustomResultDto<T> Fail( int statusCode, List<string> errors)
        {
            return new CustomResultDto<T> {  StatusCode = statusCode, Errors=errors };
        }

        public static CustomResultDto<T> Fail( int statusCode, string errors)
        {
            return new CustomResultDto<T> {  StatusCode = statusCode, Errors = new List<string> { errors } };
        }
    }
}
