using Application.DTOs.RentalApplications;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Mappers
{
    public interface IRentalApplicationMapper
    {
        RentalApplicationResponseDTO MapToDto(RentalApplication app, RentalApplicationStatus status);
    }
}
