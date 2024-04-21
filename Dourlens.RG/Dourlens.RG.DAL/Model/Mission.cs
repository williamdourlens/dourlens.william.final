namespace Dourlens.RG.DAL.Model
{
    public class Mission
    {
        public int id { get; set; }
        public int idEspion { get; set; }
        public string ville { get; set; }
        public int annee { get; set; }

        public Mission(int idEspion, string ville, int annee)
        {
            this.idEspion = idEspion;
            this.ville = ville;
            this.annee = annee;
        }

        public override string ToString()
        {
            return $"Mission {this.ville} en {this.annee} par l'espion N°{this.idEspion}.";
        }
    }

}
