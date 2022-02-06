using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VehicleBreakdownRecord.Entity.DTOs
{
    /*
     * [x] Create Static Factory Method for All Result
     */
    public class CostomResultDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public static CostomResultDto<T> Success(T data,int statusCode)
        {
            return new CostomResultDto<T> { Data = data, StatusCode = statusCode};
        }
        public static CostomResultDto<T> Success( int statusCode)
        {
            return new CostomResultDto<T> {  StatusCode = statusCode};
        }

        public static CostomResultDto<T> Fail( int statusCode, List<string> errors)
        {
            return new CostomResultDto<T> {  StatusCode = statusCode, Errors=errors };
        }

        public static CostomResultDto<T> Fail( int statusCode, string errors)
        {
            return new CostomResultDto<T> {  StatusCode = statusCode, Errors = new List<string> { errors } };
        }
    }
}
