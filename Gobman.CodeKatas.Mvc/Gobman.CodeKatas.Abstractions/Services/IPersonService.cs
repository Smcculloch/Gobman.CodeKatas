using System;
using System.Collections.Generic;
using Gobman.CodeKatas.Abstractions.Contracts;

namespace Gobman.CodeKatas.Abstractions.Services
{
    public interface IPersonService
    {
        IList<PersonCarrier> GetAll();

        PersonCarrier Get(Guid personId);

        Guid Create(PersonCarrier carrier);

        bool Update(PersonCarrier carrier);

        void Delete(Guid personId);

        Guid CreateAddress(AddressCarrier carrier);

        void SetAddress(Guid personId, Guid addressId);
    }
}
