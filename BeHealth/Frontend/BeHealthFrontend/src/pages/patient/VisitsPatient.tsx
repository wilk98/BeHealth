import './VisitsPatient.css'
import { groupBy } from '../../utils/arrays';
import { BiMessageSquare, BiCheck, HiXMark } from "react-icons/all"
import { useContext, useEffect, useState } from 'react';
import { dateToHuman, getDate, getTimeSpan } from '../../utils/calendar';
import { api_path } from '../../utils/api';
import { BeHealthContext } from '../../Context';
import { useNavigate } from 'react-router-dom';

interface Buttons {
  id: string,
  confirmed?: boolean,
  setConfirmationStatus: (arg0: string, arg1: boolean) => void,
}

const Buttons = ({ id, confirmed, setConfirmationStatus }:Buttons) => {
  const { token } = useContext(BeHealthContext)
}
  
interface Card {
  id: string,
  treatment: string,
  doctor: string,
  time: string,
  confirmed?: boolean,
  setConfirmationStatus: (arg0: string, arg1: boolean) => void,
}


const VisitCard = ({ id, treatment, doctor, time, confirmed,}: Card) => {
  return (
    <div className="card">
      <div className="title">
        <h4>{treatment}</h4>
        <p>Doctor: {doctor}</p>
      </div>
      <div className="info">
        <p className="time">{time}</p>
      </div>
    </div>
  )
}

export const VisitsPatient = () => {

  const [visits, setVisits] = useState<Array<Visit>>([])
  const { token, user } = useContext(BeHealthContext)

  const navigate = useNavigate()
  const { setUrlRedirect } = useContext(BeHealthContext)

  useEffect(() => {
    if (user === undefined) {
        setUrlRedirect("/visitsuser")
        navigate("/login")
    }
  }, [])


  const patientId = user?.id;
  const setVisitConfirmationStatus = (id: string, status: boolean) => {
    setVisits(prevVisits => prevVisits.map(visit => {
      return visit.id !== id ? visit : {
        ...visit,
        confirmed: status
      }
    })
    )
  };

  useEffect(() => {
    (async () => {
      const data = await fetch(`${api_path}/api/visits/user/${patientId}`, {
        credentials: 'include',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`
        }
      }
      );
      const json: Array<Visit> = await data.json();
      setVisits(json);
    })();
  }, [])

  interface Visit {
    id: string,
    startDate: number,
    treatment: string,
    doctor: string,
    duration: number,
  }


  const groupped = groupBy<Visit>(visits, (v) => dateToHuman(getDate(v.startDate)))
  const cards = Array<JSX.Element>();
  groupped.forEach((cardsData: Array<Visit>, date) => {
    cards.push(
      <article key={date}>
        <h3 className="day-group">{date}</h3>
        {
          cardsData.map(card => {

            return (<VisitCard key={card.id} {...card} setConfirmationStatus={setVisitConfirmationStatus} time={getTimeSpan(getDate(card.startDate), card.duration)} />)
          })
        }
      </article>
    )
  })


  return (
    <main className='visits'>
      <div className="visits-hider">
        <p>Ukryj podtwierdzone wizyty</p>
      </div>
      <div className="cards">
        {cards}
      </div>
    </main>
  )
}
