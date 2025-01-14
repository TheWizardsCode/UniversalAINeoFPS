#if NEOFPS
using NeoFPS;
#endif
using UnityEngine;

namespace WizardsCode.Common
{
    /// <summary>
    /// Describes the conditions that must be met for a mission to be considered succesful.
    /// </summary>
    [CreateAssetMenu(fileName = "New Mission Descriptor", menuName = "Wizards Code/BlazeNeo/Mission Descriptor")]
    public class MissionDescriptor : ScriptableObject
    {
        [SerializeField, Tooltip("The time allowed for the mission." +
            " The player must complete all objectives and be in the extraction zone when this time elapses." +
            " If they are in the extraction zone but have not completed on or more missions objectives they survive" +
            " but do not complete the mission. If they fail to be in the objective at the point of extraction then" +
            " they die permanently.")]
        public int m_MaxMissionTimeInMinutes = 10;

#if NEOFPS
        [SerializeField, Tooltip("The initial loadout for the character in this level.")]
        internal FpsInventoryLoadout m_InventoryLoadout;
#endif

        [SerializeField, Tooltip("How many enemies does the player need to kill in order to win the game.")]
        internal int m_ScoreNeededForTheWin = 1000;

        [SerializeField, Tooltip("How many optional targets need to be netralized for this mission to be considered a success?" +
            " Targets are identified using a `BlazeNeoMissionTarget` component. Some of these will be marked as optional.")]
        internal int minOptionalTargetsForCompletion = 0;

        [SerializeField, Tooltip("How many lives is the player given before they are considered to have lost the game.")]
        internal int m_LivesAvailable = 3;

        [SerializeField, Tooltip("The name of the scene to load upon winning.")]
        internal string m_ExtractionMissionCompleteSceneName = "ExtractionWithMissionComplete";

        [SerializeField, Tooltip("The name of the scene to load upon winning.")]
        internal string m_ExtractionMissionIncompleteSceneName = "ExtractionWithMissionIncomplete";

        [SerializeField, Tooltip("The name of the scene to load upon losing.")]
        internal string m_LosingSceneName = "Lose";

        [Header("Briefing")]
        [SerializeField, Tooltip("The full description of the mission."), TextArea(3, 15)]
        internal string m_Description;

        [Header("Difficulty")]
        [SerializeField, Tooltip("What damage multiplier should be used when setting up AI characters?" +
            " A value below 1 will result in less damage, above one will result in more damage."),
         Range(0.1f, 10f)]
        internal float m_DamageMultiplier = 1;
        [SerializeField, Tooltip("What multiplier should be used when setting up AI spawner?" +
            " A value below 1 will result in fewer enemies than the configured amount, above one will result in more spawns."),
         Range(0.1f, 10f)]
        internal float m_SpawnMultiplier = 1;

        internal float damageMultiplier
        {
            get { return m_DamageMultiplier; }
            set { m_DamageMultiplier = value; }
        }

        internal float spawnMultiplier
        {
            get { return m_SpawnMultiplier; }
            set { m_SpawnMultiplier = value; }
        }

    }
}
