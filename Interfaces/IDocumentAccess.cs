using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Interfaces
{
    public interface IDocumentAdminAccess
    {
        void CreateDocument();
        void DeleteDocument();
        void UpdateDocument();
        void ReadDocument();

    }


    public interface IDocumentEmployeeAccess
    {
        void ReadDocument();

    }
}
