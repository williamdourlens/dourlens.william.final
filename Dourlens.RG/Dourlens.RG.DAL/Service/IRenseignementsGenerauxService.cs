using Dourlens.RG.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dourlens.RG.DAL.Service
{
    public interface IRenseignementsGenerauxService
    {
        public void AddEspion(Espion espion);
        public void AddMission(Mission mission);
        public void AddMissionByEspionCode(string code, string ville, int annee);
        public void DeleteEspion(int id);
        public void DeleteMission(int id);
        public List<Espion> GetEspions();
        public List<Espion> GetEspionsByVille(string ville);
        public List<Mission> GetMissions();
        public void UpdateEspion(int actualEspionId, string newNom, string newCode);
        public void UpdateMission(int actualMissionId, int newIdEspion, string newVille, int newAnnee);
    }
}
