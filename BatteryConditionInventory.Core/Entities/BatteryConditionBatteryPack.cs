namespace BatteryConditionInventory.Core.Entities
{
    public class BatteryConditionBatteryPack
    {
        public int? BatteryConditionId { get; set; }
        public BatteryCondition BatteryCondition { get; set; }

        public int? BatteryPackId { get; set; }
        public BatteryPack BatteryPack { get; set; }
    }
}