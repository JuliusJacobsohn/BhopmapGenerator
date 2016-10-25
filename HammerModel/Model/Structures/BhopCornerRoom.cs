using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerModel.Model.Units;
using HammerModel.Helpers;

namespace HammerModel.Model.Structures
{
    public class BhopCornerRoom : TextureObject, ISpawnable
    {
        private List<ICornerroomElement> roomElements;
        public BhopCornerRoom()
        {
            roomElements = new List<ICornerroomElement>();
        }

        public override ValueTriple GetOrigin()
        {
            throw new NotImplementedException();
        }

        public ValueTriple GetSpawnCoordinates()
        {
            throw new NotImplementedException();
        }

        public override List<HammerObject> ToHammerObject()
        {
            throw new NotImplementedException();
        }

        public class StartElement : ICornerroomElement
        {

        }

        public class EndElement : ICornerroomElement
        {

        }

        public class CornerElement : ICornerroomElement
        {

        }

        public class LineElement : ICornerroomElement
        {

        }

        public interface ICornerroomElement
        {

        }
    }
}
