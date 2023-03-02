import { useEffect, useState,useContext } from "react";
import { api_path } from '../../utils/api';
import axios from "axios";
import { BeHealthContext } from '../../Context';




interface Referral {
    id: number;
    firstName: string;
    lastName: string;
  }
  
  const Referrals: React.FC = () => {
    const [referrals, setReferrals] = useState<Referral[]>([]);
    const { token, user } = useContext(BeHealthContext)
    const userId = user?.id;

    

  
    useEffect(() => {
      (async () => {
        const data = await fetch(`${api_path}/api/referrals/${userId}`, {
          credentials: 'include',
          headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
          }
        }
        );
        const json: Array<Referral> = await data.json();
        setReferrals(json);
      })();
    }, [])
  
    const renderTables = () => {
      const tableRows: JSX.Element[] = [];
  
      for (let i = 0; i < Math.ceil(referrals.length / 5); i++) {
        const start = i * 5;
        const end = start + 5;
  
        const tableData = referrals.slice(start, end);
  
        const tableRowsData = tableData.map((referral) => (
          <tr key={referral.id}>
            <td>{referral.firstName} {referral.lastName}</td>
            <td>{new Date().toLocaleDateString()}</td>
            <td>Specjalista</td>
            <td>Opis</td>
            <td>Kod</td>
          </tr>
        ));
  
        tableRows.push(
          <table key={`table-${i}`}>
            <thead>
              <tr>
                <th>Pacjent</th>
                <th>Data wystawienia</th>
                <th>Specjalista</th>
                <th>Opis</th>
                <th>Kod</th>
              </tr>
            </thead>
            <tbody>
              {tableRowsData}
            </tbody>
          </table>
        );
      }
  
      return tableRows;
    };
  
    return (
      <div className="table-container">
        {renderTables()}
      </div>
    );
  };
  
  export default Referrals;
