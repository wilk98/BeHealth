import './Calendar.css'

import { useEffect, useState } from 'react';
import { getCurrentMonth, getCurrentYear, getDaysInMonth, getMonthName, getWeekDays } from '../../utils/calendar';
import { api_path } from '../../utils/api';
import { MonthSelector } from '../../components/ui/MonthSelector';

interface CalendarDay {
    day: number,
    showVisit?: boolean,
    visits: number
}
interface VisitData {
    day: number,
    visits: number
}

const CalendarDay = ({ day, visits, showVisit = true }: CalendarDay) => {
    const s = (n: number): string => {
        const lastDigit = Number(String(n).slice(-1));
        switch (lastDigit) {
            case 2:
            case 3:
            case 4:
                return 'y'
            case 1:
                return 'a'
            default:
                return ''
        }
    }

    return (
        <div className={`calendar-day ${showVisit ? '' : 'disabled '} ${visits == 0 || visits == -1 ? 'no-visits ' : ''}`}>
            <p className='date'>{String(day).padStart(2, '0')}</p>
            <p className={`visits ${visits === -1 ? 'loading' : ''}`}style={{ opacity: showVisit ? 1 : 0 }}>{visits} wizyt{s(visits)}</p>
        </div>
    )
}

export const Calendar = () => {
    const [offset, setOffset] = useState(0);
    const [visits, setVisits] = useState<Array<VisitData>>();


    const currentYear = getCurrentYear()
    const currentMonth = getCurrentMonth() + offset
    const doctorId = 1;

    const fetchData = async (abortController: AbortController) => {
        const date = new Date(currentYear, currentMonth)
        const year = date.getFullYear()
        const month = date.getUTCMonth() + 1

        return await fetch(`${api_path}/api/visits/calendar/${doctorId}?year=${year}&month=${month}`, {
                        signal: abortController.signal});
    }

    useEffect(() => {
        const abortController = new AbortController();
        const delayLoadingAnimation = setTimeout(() => {
            setVisits(undefined);
        }, 50);

        (async () => {
            try {
                const data = await fetchData(abortController)
                const visits:Array<VisitData> = await data.json()
                clearTimeout(delayLoadingAnimation)
                setVisits(visits);
            } catch (error) { }
        }
        )();
      return () => {
        clearTimeout(delayLoadingAnimation)
        abortController.abort()
      }
    }, [offset])

    const daysOfWeek = getWeekDays('pl-PL', true).map(day => <p key={day}>{day}</p>);
    const calendarDays = (() => {
        const daysElements = Array<JSX.Element>();
        const daysInCurrentMonth = getDaysInMonth(currentYear, currentMonth)
        const daysInPreviousMonth = getDaysInMonth(currentYear, currentMonth - 1);
        const monthStartsWith = new Date(currentYear, currentMonth - 1, 1).getUTCDay();

        for (let i = daysInPreviousMonth - monthStartsWith + 1; i <= daysInPreviousMonth; i++) {
            daysElements.push(<CalendarDay key={i*3} day={i} visits={0} showVisit={false} />)
        }
        for (let i = 1; i <= daysInCurrentMonth; i++) {
            const visitsAtDay = visits === undefined ? -1 : (visits?.find(v => v.day == i)?.visits ?? 0)
            daysElements.push(<CalendarDay key={i} day={i} visits={visitsAtDay} />)
        }
        return daysElements;
    })();


    const selectMonth = (n: -1 | 1) => {
        if (visits !== undefined) {
            setVisits([])
        }
        setOffset(prev => prev + n);
    }

    return (
        <main className='calendar'>
            <section className="body">
                <section id='head'>
                    <MonthSelector selectNextMonth={() => selectMonth(1)} selectPrevMonth={() => selectMonth(-1)} offset={offset} />
                    <hr />
                    <div className="days-of-week">{daysOfWeek}</div>
                </section>
                <section id='body'>
                    {calendarDays}
                </section>
            </section>
        </main>
    )
}