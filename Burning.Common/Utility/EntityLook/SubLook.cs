using Burning.DofusProtocol.Enums;
using Burning.DofusProtocol.Network.Types;

namespace Burning.Common.Utility.EntityLook
{
    public class SubLook
    {
        private SubEntityBindingPointCategoryEnum m_bindingCategory;
        private sbyte m_bindingIndex;
        private Look m_look;
        public sbyte BindingIndex
        {
            get
            {
                return this.m_bindingIndex;
            }
            set
            {
                this.m_bindingIndex = value;
            }
        }
        public SubEntityBindingPointCategoryEnum BindingCategory
        {
            get
            {
                return this.m_bindingCategory;
            }
            set
            {
                this.m_bindingCategory = value;
            }
        }

        public SubLook(sbyte index, SubEntityBindingPointCategoryEnum category, Look look)
        {
            this.m_bindingIndex = index;
            this.m_bindingCategory = category;
            this.m_look = look;

        }
        public Look Look
        {
            get { return m_look; }
        }
        public override string ToString()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append((sbyte)this.BindingCategory);
            stringBuilder.Append("@");
            stringBuilder.Append(this.BindingIndex);
            stringBuilder.Append("=");
            stringBuilder.Append(this.Look);
            return stringBuilder.ToString();
        }

        public SubEntity GetSubEntity()
        {
            return new SubEntity((uint)BindingCategory, (uint)BindingIndex, Look.GetEntityLook());
        }
    }
}