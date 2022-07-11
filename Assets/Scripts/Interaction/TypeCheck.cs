public static class TypeCheck
{
    public static bool IsItemSuitable(ItemType itemType, IncidentType incidentType)
    {
        if (incidentType == IncidentType.Fire)
        {
            return itemType == ItemType.FireExtinguisher;
        }

        return false;
    }
}
