using Symptoms.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symptoms.Client.Rules
{
    internal interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
        string ErrorMessage { get; }
    }
}
