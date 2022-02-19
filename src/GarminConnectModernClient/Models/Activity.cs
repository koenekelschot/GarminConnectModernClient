namespace GarminConnectModernClient.Models
{
    public class Activity
    {
        public long ActivityId { get; set; }
	    public string? ActivityName { get; set; }
	    public string? Description { get; set; }
        public DateTime StartTimeLocal { get; set; }
        public DateTime StartTimeGMT { get; set; }
        public ExtendedActivityLabel? ActivityType { get; set; }
        public SortedActivityLabel? EventType { get; set; }
        // Comments
        public long? ParentId { get; set; }
        public double? Distance { get; set; }
        public double Duration { get; set; }
        public double ElapsedDuration { get; set; }
        public double MovingDuration { get; set; }
        public double? ElevationGain { get; set; }
        public double? ElevationLoss { get; set; }
        public double? AverageSpeed { get; set; }
        public double? MaxSpeed { get; set; }
        public double? StartLatitude { get; set; }
        public double? StartLongitude { get; set; }
        public bool HasPolyline { get; set; }
        public long OwnerId { get; set; }
        public string OwnerDisplayName { get; set; } = "";
        public string OwnerFullName { get; set; } = "";
        public Uri? OwnerProfileImageSmall { get; set; }
        public Uri? OwnerProfileImageMedium { get; set; }
        public Uri? OwnerProfileImageLarge { get; set; }
        public double? Calories { get; set; }
        public double? AverageHR { get; set; }
        public double? MaxHR { get; set; }
        public double? AverageRunningCadenceInStepsPerMinute { get; set; }
        public double? MaxRunningCadenceInStepsPerMinute { get; set; }
        public double? AverageBikingCadenceInRevPerMinute { get; set; }
        public double? MaxBikingCadenceInRevPerMinute { get; set; }
        public double? AverageSwimCadenceInStrokesPerMinute { get; set; }
        public double? MaxSwimCadenceInStrokesPerMinute { get; set; }
        // AverageSwolf
        // ActiveLengths
        public long? Steps { get; set; }
        // ConversationUuid
        // ConversationPk
        public int? NumberOfActivityLikes { get; set; }
        public int? NumberOfActivityComments { get; set; }
        // LikedByUser
        // CommentedByUser
        // ActivityLikeDisplayNames
        // ActivityLikeFullNames
        // ActivityLikeProfileImageUrls
        // RequestorRelationship
        public string[] UserRoles { get; set; } = Array.Empty<string>();
        public ActivityLabel? Privacy { get; set; }
        public bool UserPro { get; set; }
        public long? CourseId { get; set; }
        public double? PoolLength { get; set; }
        public string? UnitOfPoolLength { get; set; }
        public bool HasVideo { get; set; }
        public Uri? VideoUrl { get; set; }
        public int TimeZoneId { get; set; }
        public long BeginTimestamp { get; set; }
        public int SportTypeId { get; set; }
        // AvgPower
        // MaxPower
        public double? AerobicTrainingEffect { get; set; }
        public double? AnaerobicTrainingEffect { get; set; }
        public double? Strokes { get; set; }
        // NormPower
        // LeftBalance
        // RightBalance
        // AvgLeftBalance
        // Max20MinPower
        // AvgVerticalOscillation
        // AvgGroundContactTime
        // AvgStrideLength
        // AvgFractionalCadence
        // MaxFractionalCadence
        // TrainingStressScore
        // IntensityFactor
        // VO2MaxValue
        // AvgVerticalRatio
        // AvgGroundContactBalance
        // LactateThresholdBpm
        // LactateThresholdSpeed
        // MaxFtp
        // AvgStrokeDistance
        // AvgStrokeCadence
        public double? MaxStrokeCadence { get; set; }
        public long? WorkoutId { get; set; }
        // AvgStrokes
        // MinStrokes
        public long DeviceId { get; set; }
        public double? MinTemperature { get; set; }
        public double? MaxTemperature { get; set; }
        public double? MinElevation { get; set; }
        public double? MaxElevation { get; set; }
        // AvgDoubleCadence
        // MaxDoubleCadence
        // SummarizedExerciseSets
        // MaxDepth
	    // AvgDepth
	    // SurfaceInterval
	    // StartN2
	    // EndN2
	    // StartCns
	    // EndCns
        // SummarizedDiveInfo
        // ActivityLikeAuthors
        public double? AvgVerticalSpeed { get; set; }
        public double? MaxVerticalSpeed { get; set; }
        public double? FloorsClimbed { get; set; }
        public double? FloorsDescended { get; set; }
        public string Manufacturer { get; set; } = "";
        public long? DiveNumber { get; set; }
        public string? LocationName { get; set; }
        // BottomTime
        public int? LapCount { get; set; }
        public double? EndLatitude { get; set; }
        public double? EndLongitude { get; set; }
        // MinAirSpeed
	    // MaxAirSpeed
	    // AvgAirSpeed
	    // AvgWindYawAngle
	    // MinCda
	    // MaxCda
	    // AvgCda
	    // AvgWattsPerCda
	    // Flow
	    // Grit
	    // JumpCount
        public double? CaloriesEstimated { get; set; }
	    public double? CaloriesConsumed { get; set; }
	    public double? WaterEstimated { get; set; }
	    public double? WaterConsumed { get; set; }
        // MaxAvgPower_1
        // MaxAvgPower_2
        // MaxAvgPower_5
        // MaxAvgPower_10
        // MaxAvgPower_20
        // MaxAvgPower_30
        // MaxAvgPower_60
        // MaxAvgPower_120
        // MaxAvgPower_300
        // MaxAvgPower_600
        // MaxAvgPower_1200
        // MaxAvgPower_1800
        // MaxAvgPower_3600
        // MaxAvgPower_7200
        // MaxAvgPower_18000
        // ExcludeFromPowerCurveReports
	    // TotalSets
	    // ActiveSets
	    // TotalReps
	    // MinRespirationRate
	    // MaxRespirationRate
	    // AvgRespirationRate
        public string? TrainingEffectLabel { get; set; }
        public double? ActivityTrainingLoad { get; set; }
        // AvgFlow
        // AvgGrit
        public double? MinActivityLapDuration { get; set; }
        // AvgStress
	    // StartStress
	    // EndStress
	    // DifferenceStress
	    // MaxStress
        public string? AerobicTrainingEffectMessage { get; set; }
        public string? AnaerobicTrainingEffectMessage { get; set; }
        // SplitSummaries
        public bool HasSplits { get; set; }
        public int? ModerateIntensityMinutes { get; set; }
        public int? VigorousIntensityMinutes { get; set; }
        // MaxBottomTime
	    // HasSeedFirstbeatProfile
	    // CalendarEventId
	    // CalendarEventUuid
        public bool Parent { get; set; }
        public bool Favorite { get; set; }
        public bool DecoDive { get; set; }
        public bool Purposeful { get; set; }
        public bool Pr { get; set; }
        public bool AutoCalcCalories { get; set; }
        public bool AtpActivity { get; set; }
        public bool ManualActivity { get; set; }
        public bool ElevationCorrected { get; set; }
    }

    public class ActivityLabel
    {
        public int TypeId { get; set; }
        public string TypeKey { get; set; } = "";
    }

    public class SortedActivityLabel : ActivityLabel
    {
        public int SortOrder { get; set; }
    }

    public class ExtendedActivityLabel : SortedActivityLabel
    {
        public int ParentTypeId { get; set; }
        public bool IsHidden { get; set; }
        public bool Restricted { get; set; }
        public bool Trimmable { get; set; }
    }
}
