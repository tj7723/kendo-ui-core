namespace Kendo.Mvc.UI
{
    using System.Collections.Generic;
    using Kendo.Mvc.Infrastructure;
    using Kendo.Mvc.Extensions;

    internal class GaugeRadialPointerSerializer<T> : IChartSerializer
        where T : struct
    {
        private readonly GaugeRadialPointer<T> pointer;

        public GaugeRadialPointerSerializer(GaugeRadialPointer<T> pointer)
        {
            this.pointer = pointer;
        }

        public virtual IDictionary<string, object> Serialize()
        {
            var result = new Dictionary<string, object>();

            FluentDictionary.For(result)
                .Add("color", pointer.Color, () => pointer.Color.HasValue())
                .Add("opacity", pointer.Opacity, () => pointer.Opacity.HasValue)
                .Add("value", pointer.Value, () => pointer.Value.HasValue);

            var cap = pointer.Cap.CreateSerializer().Serialize();

            if (cap.Count > 0) 
            {
                result.Add("cap", cap);
            }

            return result;
        }
    }
}