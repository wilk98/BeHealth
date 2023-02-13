import './Visits.css'
import { groupBy } from '../../utils/arrays';
import { BiMessageSquare, BiCheck, HiXMark } from "react-icons/all"
import { useEffect, useState } from 'react';
import { dateToHuman, getDate, getTimeSpan } from '../../utils/calendar';
import { api_path } from '../../utils/api';

interface Buttons {
  id: string,
  confirmed?: boolean,
  setConfirmationStatus: (arg0: string, arg1: boolean) => void,
}

const Buttons = ({ id, confirmed, setConfirmationStatus }:Buttons) => {
  function handleVisitClick(id: string, status: boolean, setConfirmationStatus: (arg0: string, arg1: boolean) => void) {
    setConfirmationStatus(id, status);
    fetch(`${api_path}/api/visits/${id}/${status ? 'accept' : 'decline'}`, {
      method: "POST"
    });
  }
  return (
    <div className="buttons">
      {
        confirmed !== null &&
        <div className="confirmation-status">
          <p>{confirmed ? 'Potwierdzono' : 'Anulowano'}</p>
        </div>
      }
      <div className="message">
        <BiMessageSquare className='' />
      </div>
      {
        ((confirmed === null) || (confirmed === false)) &&
        (
          <div className="accept" onClick={() => handleVisitClick(id, true, setConfirmationStatus)}>
            <BiCheck className='' />
          </div>
        )
      }
      {
        ((confirmed === null) || (confirmed === true)) &&
        (
          <div className="decline">
            <HiXMark className='' onClick={() => handleVisitClick(id, false, setConfirmationStatus)} />
          </div>
        )
      }
    </div>
  )
}

interface Card {
  id: string,
  treatment: string,
  patient: string,
  time: string,
  confirmed?: boolean,
  setConfirmationStatus: (arg0: string, arg1: boolean) => void,
}


const VisitCard = ({ id, treatment, patient, time, confirmed, setConfirmationStatus }: Card) => {
  return (
    <div className="card">
      <div className="title">
        <h4>{treatment}</h4>
        <p>Pacjent: {patient}</p>
      </div>
      <div className="info">
        <p className="time">{time}</p>
        <Buttons id={id} confirmed={confirmed} setConfirmationStatus={setConfirmationStatus} />
      </div>
    </div>
  )
}

export const Visits = () => {

  const doctorId = "1";
  const [visits, setVisits] = useState<Array<Visit>>([])
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
      const data = await fetch(`${api_path}/api/visits/${doctorId}`, {
        headers: {
          'Content-Type': 'application/json',
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
    patient: string,
    duration: number,
    confirmed?: boolean,
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
