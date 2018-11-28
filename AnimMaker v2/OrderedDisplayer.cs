using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimMaker_v2
{
    internal struct OrderedDisplayer : IEquatable<OrderedDisplayer>
    {
        #region Public Constructors

        public OrderedDisplayer(WGP.SFDynamicObject.IBaseElement obj)
        {
            ID = obj.ID;
            Name = obj.Name;
        }

        public OrderedDisplayer(Guid id, string name)
        {
            ID = id;
            Name = name;
        }

        #endregion Public Constructors

        #region Private Properties

        public Guid ID { get; set; }
        public string Name { get; set; }

        #endregion Private Properties

        #region Public Methods

        public static bool operator !=(OrderedDisplayer left, OrderedDisplayer right) => !left.Equals(right);

        public static bool operator ==(OrderedDisplayer left, OrderedDisplayer right) => left.Equals(right);

        public override bool Equals(object obj) => ID.Equals(((OrderedDisplayer)obj).ID);

        public bool Equals(OrderedDisplayer other) => ID.Equals(other.ID);

        public override int GetHashCode() => ID.GetHashCode();

        public override string ToString()
        {
            return Name;
        }

        #endregion Public Methods
    }
}