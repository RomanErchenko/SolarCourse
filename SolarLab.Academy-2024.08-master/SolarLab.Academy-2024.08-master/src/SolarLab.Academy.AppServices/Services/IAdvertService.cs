﻿using SolarLab.Academy.Contracts.Adverts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.AppServices.Services
{
    public interface IAdvertService
    {
        Task<List<AdvertDto>> GetAll();
    }
}
