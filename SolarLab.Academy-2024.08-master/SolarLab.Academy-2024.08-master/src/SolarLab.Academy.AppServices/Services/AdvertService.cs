using AutoMapper;


using SolarLab.Academy.AppServices.Repository;
using SolarLab.Academy.Contracts.Adverts;
using SolarLab.Academy.Domain.Advert;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SolarLab.Academy.AppServices.Services
{
    public class AdvertService :IAdvertService
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public AdvertService(IAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
        }

        public async Task<List<AdvertDto>> GetAll(CancellationToken cancellationToken)
        {
            List<AdvertDto> advert =await _advertRepository.GetAll(cancellationToken);
           
               

            return advert;
            
        }
        

    }
}