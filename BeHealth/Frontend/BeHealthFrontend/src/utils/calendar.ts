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

export { dateToHuman, getDate, getTimeSpan }