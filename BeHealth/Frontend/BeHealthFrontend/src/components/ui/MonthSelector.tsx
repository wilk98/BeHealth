import { IoCaretBack, IoCaretForward } from "react-icons/io5"
import { getCurrentMonth, getCurrentYear, getMonthName } from "../../utils/calendar"

interface MonthSelector {
    selectPrevMonth: () => void,
    selectNextMonth: () => void,
    offset: number
}

export const MonthSelector = ({ selectPrevMonth, selectNextMonth, offset }: MonthSelector) => {

    const selectedMonth = getCurrentMonth() + offset - 1
    const selectedMonthName = getMonthName(selectedMonth, 'pl-PL')
    const selectedYear = new Date(getCurrentYear(), selectedMonth).getFullYear()

    return (
        <>
            <div className="month-control">
                <button onClick={selectPrevMonth}><IoCaretBack /></button>
                <div className="spacer">
                    <h3 style={{ textTransform: 'capitalize' }}>{selectedMonthName} {selectedYear}</h3>
                </div>
                <button onClick={selectNextMonth}><IoCaretForward /></button>
            </div>
            <div className="month-control-mobile">
                <h3 style={{ textTransform: 'capitalize' }}>{selectedMonthName} {selectedYear}</h3>
                <div className="buttons-row">
                    <button onClick={selectPrevMonth}><IoCaretBack /></button>
                    <button onClick={selectNextMonth}><IoCaretForward /></button>
                </div>
            </div>
        </>
    )
}