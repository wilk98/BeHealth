import { useEffect, useState,useContext } from "react";
import { api_path } from '../../utils/api';
import { BeHealthContext } from '../../Context';
import "./Referrals.css";
import { BsDownload } from "react-icons/bs";


interface Referral {
  downloadLink: string | undefined;
  patient: string;
  date: string;
  specialist: string;
  description: string;
  code: string;
}

export function Referrals() {
  const [referrals, setReferrals] = useState<Referral[]>([]);
  const { token, user } = useContext(BeHealthContext)
  const userId = user?.id;

  useEffect(() => {
    fetch(`${api_path}/api/referrals/${userId}`)
      .then(response => response.json())
      .then(data => setReferrals(data))
      .catch(error => console.error(error));
  }, []);
  
  const createTable = (referral: Referral) => {
    return (
      <table>
        <thead>
          <tr>
            <th style={{ width: "130px", textAlign: "center" }}>Pacjent</th>
            <th>Data wystawienia</th>
            <th>Specjalista</th>
            <th>Opis</th>
            <th>Kod</th>
            <th>Pobierz</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td style={{textAlign: "center"}}>{referral.patient}</td>
            <td>{new Date(referral.date).toLocaleDateString()}</td>
            <td>{referral.specialist}</td>
            <td>{referral.description}</td>
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

    for (let i = 0; i < referrals.length; i++) {
      tableRows.push(createTable(referrals[i]));

      if (tableRows.length === MAX_ROWS_PER_TABLE || i === referrals.length - 1) {
        tables.push(<div className="table-container">{tableRows}</div>);
        tableRows = [];
      }
    }

    return tables;
  };

  return (
    <div className="referrals">
      {referrals.length > 0 ? (
        createTables()
      ) : (
        <p>BRAK WYSTAWIONYCH SKIEROWAŃ</p>
      )}
    </div>
  );
}




