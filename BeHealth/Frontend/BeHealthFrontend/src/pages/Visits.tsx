import './Visits.css'
import { groupBy } from '../utils/arrays';
import { BiMessageSquare, BiCheck, HiXMark } from "react-icons/all"
import { useEffect, useState } from 'react';
import { dateToHuman, getDate, getTimeSpan } from '../utils/calendar';

interface Card {
  treatment: string,
  patient: string,
  time: string,
}

const VisitCard = ({ treatment, patient, time}:Card ) => {
  return (
    <div className="card">
      <div className="title">
        <h4>{treatment}</h4>
        <p>Pacjent: {patient}</p>
      </div>
      <div className="info">
        <p className="time">{time}</p>
        <div className="buttons">
          <div className="message">
            <BiMessageSquare className='' />
          </div>
          <div className="accept">
            <BiCheck className='' />
          </div>
          <div className="decline">
            <HiXMark className='' />
          </div>
        </div>
      </div>
    </div>
  )
}

export const Visits = () => {

  const doctorId = "25A4CBB5-B31C-40B6-A536-396ABDC1833D";
  const [visits, setVisits] = useState<Array<Visit>>([])
  useEffect(() => {
    (async () => {
      const data = await fetch(`https://localhost:44319/api/visits/${doctorId}`, {
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
    id: number,
    startDate: number;
    treatment: string;
    patient: string;
    duration: number;
  }


  const groupped = groupBy<Visit>(visits, (v) => dateToHuman(getDate(v.startDate)))
  const cards = Array<JSX.Element>();
  groupped.forEach((cardsData: Array<Visit>, date) => {
    cards.push(
      <article key={date}>
        <h3 className="day-group">{date}</h3>
        {
          cardsData.map(card => (
            <VisitCard key={card.id} {...card} time={getTimeSpan(getDate(card.startDate), card.duration)} />
          ))
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
