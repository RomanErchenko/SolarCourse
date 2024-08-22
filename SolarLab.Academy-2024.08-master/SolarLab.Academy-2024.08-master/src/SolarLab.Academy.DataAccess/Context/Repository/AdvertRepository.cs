﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.Repository;
using SolarLab.Academy.Contracts.Adverts;
using SolarLab.Academy.Domain.Advert;
using SolarLab.Academy.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.DataAccess.Context.Repository
{
    public class AdvertRepository : IAdvertRepository
    {

        private readonly IRepository<Advert> _repository;
        private readonly IMapper _mapper;

        public AdvertRepository(IRepository<Advert> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }

        public async Task<List<AdvertDto>> GetAll(CancellationToken cancellationToken)
        {
            var advert =await _repository.GetAll().ToListAsync(cancellationToken);
            List<AdvertDto> notess = _mapper.Map<List<Advert>, List<AdvertDto>>(advert);


            return notess;


        }
    }
}
