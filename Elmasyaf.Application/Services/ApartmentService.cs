using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elmasyaf.Application.Interfaces;
using AutoMapper;



using System.Numerics;
using Elmasyaf.Domain.Interfaces;
using Elmasyaf.Application.DTOs;
using Elmasyaf.Domain.Entities;

namespace Elmasyaf.Application.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ApartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<ApartmentCardDTO>> GetAllAsync()
        {
            var apartments = await _unitOfWork.Properties.GetAllAsync();
            return _mapper.Map<IEnumerable<ApartmentCardDTO>>(apartments);
        }
        public async Task<ApartmentCardDTO> GetByIdAsync(long id)
        {
            var apartment = await _unitOfWork.Properties.GetByIdAsync(id);
            return _mapper.Map<ApartmentCardDTO>(apartment);
        }
        public async Task AddAsync(ApartmentCardDTO apartmentDto)
        {
            if (apartmentDto == null)
            {
                throw new ArgumentNullException(nameof(apartmentDto));
            }
            var apartment = _mapper.Map<Property>(apartmentDto);
            await _unitOfWork.Properties.AddAsync(apartment);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateAsync(ApartmentCardDTO apartmentDto)
        {
            if (apartmentDto == null)
            {
                throw new ArgumentNullException(nameof(apartmentDto));
            }
            var apartment = _mapper.Map<Property>(apartmentDto);
            _unitOfWork.Properties.Update(apartment);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(long id)
        {
            var apartment = await _unitOfWork.Properties.GetByIdAsync(id);
            if (apartment == null)
            {
                throw new KeyNotFoundException($"Apartment with ID {id} not found.");
            }
            _unitOfWork.Properties.Delete(apartment);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
