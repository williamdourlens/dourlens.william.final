using Dourlens.RG.DAL.DAL;
using Dourlens.RG.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dourlens.RG.DAL.Service
{
    public class RenseignementsGenerauxService : IRenseignementsGenerauxService
    {
        private DourlensDbContext _db;
        public RenseignementsGenerauxService(DourlensDbContext dbContext)
        {
            this._db = dbContext;
        }

        public void AddEspion(Espion espion)
        {
            this._db.Espions.Add(espion);
            this._db.SaveChanges();
        }

        public void AddMission(Mission mission)
        {
            this._db.Missions.Add(mission);
            this._db.SaveChanges();
        }

        public void AddMissionByEspionCode(string code, string ville, int annee)
        {
            var espion = this._db.Espions.Where(e => e.code == code).FirstOrDefault();
            if (espion == null)
            {
                throw new Exception("Espion non trouvé");
            }

            Mission mission = new Mission(espion.id, ville, annee);

            this._db.Missions.Add(mission);
            this._db.SaveChanges();
        }

        public void DeleteEspion(int id)
        {
            var espion = this._db.Espions.Find(id);
            this._db.Espions.Remove(espion);
            this._db.SaveChanges();
        }

        public void DeleteMission(int id)
        {
            var mission = this._db.Missions.Find(id);
            this._db.Missions.Remove(mission);
            this._db.SaveChanges();
        }

        public List<Espion> GetEspions()
        {
            return this._db.Espions.ToList();
        }

        public List<Espion> GetEspionsByVille(string ville)
        {
            var espions = from espion in _db.Espions
                          join mission in _db.Missions on espion.id equals mission.idEspion
                          where mission.ville == ville
                          select espion;

            return espions.ToList();
        }

        public List<Mission> GetMissions()
        {
            return this._db.Missions.ToList();
        }

        public void UpdateEspion(int actualEspionId, string newNom, string newCode)
        {
            var actualEspion = this._db.Espions.Find(actualEspionId);
            actualEspion.nom = newNom;
            actualEspion.code = newCode;
            this._db.SaveChanges();
        }

        public void UpdateMission(int actualMissionId, int newIdEspion, string newVille, int newAnnee)
        {
            var actualMission = this._db.Missions.Find(actualMissionId);
            actualMission.idEspion = newIdEspion;
            actualMission.ville = newVille;
            actualMission.annee = newAnnee;
            this._db.SaveChanges();
        }
    }
}
