import { useEffect, useState,useContext } from "react";
import { api_path } from '../../utils/api';
import { BeHealthContext } from '../../Context';
import "./Referrals.css";
import { BsDownload } from "react-icons/bs";


interface Recipe {
  downloadLink: string | undefined;
  patient: string;
  date: string;
  medicament: string;
  quantity: number;
  code: string;
}

export function Recipes() {
  const [recipes, setRecipes] = useState<Recipe[]>([]);
  const { token, user } = useContext(BeHealthContext)
  const userId = user?.id;

  useEffect(() => {
    fetch(`${api_path}/api/recipes/${userId}`)
      .then(response => response.json())
      .then(data => setRecipes(data))
      .catch(error => console.error(error));
  }, []);
  
  const createTable = (referral: Recipe) => {
    return (
      <table>
        <thead>
          <tr>
            <th style={{ width: "130px", textAlign: "center" }}>Pacjent</th>
            <th>Data wystawienia</th>
            <th>Lekarstwo</th>
            <th>Ilość</th>
            <th>Kod</th>
            <th>Pobierz</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td style={{textAlign: "center"}}>{referral.patient}</td>
            <td>{new Date(referral.date).toLocaleDateString()}</td>
            <td>{referral.medicament}</td>
            <td>{referral.quantity}</td>
            <td>{referral.code}</td>
            <td style={{ textAlign: "center" }}>
                  <BsDownload />
            </td>
          </tr>
        </tbody>
      </table>
    );
  };

  const createTables = () => {
    const MAX_ROWS_PER_TABLE = 10;
    const tables = [];
    let tableRows = [];

    for (let i = 0; i < recipes.length; i++) {
      tableRows.push(createTable(recipes[i]));

      if (tableRows.length === MAX_ROWS_PER_TABLE || i === recipes.length - 1) {
        tables.push(<div className="table-container">{tableRows}</div>);
        tableRows = [];
      }
    }

    return tables;
  };

  return (
    <div className="referrals">
      {recipes.length > 0 ? (
        createTables()
      ) : (
        <p>BRAK WYSTAWIONYCH RECEPT</p>
      )}
    </div>
  );
}




