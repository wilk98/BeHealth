import './Visits.css'
import { BiMessageSquare, BiCheck, HiXMark } from "react-icons/all"
import { useEffect, useState } from 'react';

export const Visits = () => {

  const [visits, setVisits] = useState<Array<Visit>>([])
  useEffect(() => {
    (async () => {
      const data = await fetch("https://localhost:7060/api/visits", {
        headers: {
        'Content-Type': 'application/json',
        }
      }
      );
      const json:Array<Visit> = await data.json();
      setVisits(json);
    })();
  }, [])
    

  function groupBy<T>(list: Array<T>, keyGetter: (arg0: T) => any) {
    const map = new Map();
    list.forEach((item) => {
      const key = keyGetter(item);
      const collection = map.get(key);
      if (!collection) {
        map.set(key, [item]);
      } else {
        collection.push(item);
      }
    });
    return map;
  }

  interface Visit {
    startDate: number;
    treatment: string;
    patient: string;
    duration: number;
  }

  const monthNames: Array<string> = [
    "Stycznia",
    "Lutego",
    "Marca",
    "Kwietnia",
    "Maja",
    "Czerwca",
    "Lipca",
    "Sierpnia",
    "Września",
    "Października",
    "Listopada",
    "Grudnia"
  ]

  const getDate = (timestamp: number) => new Date(timestamp * 1000);
  const dateToHuman = (date: Date) => `${date.getDate()} ${monthNames[date.getMonth()]}`;
  const getHumanTime = (hours: number, minutes: number) => `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}`;
  const getTimeSpan = (startDate: Date, minutesDuration: number) => {
    const toDate = new Date(startDate.valueOf() + minutesDuration * 60 * 1000)
    return `${getHumanTime(startDate.getHours(), startDate.getMinutes())} - ${getHumanTime(toDate.getHours(), toDate.getMinutes())}`
  };

  const groupped = groupBy<Visit>(visits, (v) => dateToHuman(getDate(v.startDate)))
  const cards = Array<JSX.Element>();
  groupped.forEach((cardsData: Array<Visit>, date) => {
    cards.push(
      <>
        <h3 className="day-group">{date}</h3>
        {
          cardsData.map(card => (
            <div className="card">
              <div className="title">
                <h4>{card.treatment}</h4>
                <p>Pacjent: {card.patient}</p>
              </div>
              <div className="info">
                <p className="time">{getTimeSpan(getDate(card.startDate), card.duration)}</p>
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
            </div>))
        }
      </>
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
