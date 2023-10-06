﻿using MekashronTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MekashronTest.Domain.Responses
{
    public interface IBaseResponse<T>
    {
        public string Description { get; }

        public StatusCode StatusCode { get; }

        public T Data { get; }
    }

    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
}
