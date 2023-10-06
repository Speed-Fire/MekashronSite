﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MekashronTest.Domain.Enums
{
    public enum StatusCode
    {
        OK = 200,
        InternalServerError = 500,
        TaskAlreadyExist = 1,
        NotFound = 404
    }
}
