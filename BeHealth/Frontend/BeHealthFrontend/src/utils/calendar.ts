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
const getHumanTime = (hours: number, minutes: number) => `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}`;

export const getDate = (timestamp: number) => new Date(timestamp * 1000);
export const dateToHuman = (date: Date) => `${date.getDate()} ${monthNames[date.getMonth()]}`;
export const getTimeSpan = (startDate: Date, minutesDuration: number) => {
    const toDate = new Date(startDate.valueOf() + minutesDuration * 60 * 1000)
    return `${getHumanTime(startDate.getHours(), startDate.getMinutes())} - ${getHumanTime(toDate.getHours(), toDate.getMinutes())}`
};
export const getWeekDays = (locale: string, long: boolean) => {
    const baseDate = new Date(Date.UTC(2017, 0, 2)); // just a Monday
    const weekDays = [];
    for(let i = 0; i < 7; i++)
    {       
        weekDays.push(baseDate.toLocaleDateString(locale, { weekday: long ? 'long' : 'short' }));
        baseDate.setDate(baseDate.getDate() + 1);       
    }
    return weekDays;
}
export const getDaysInMonth = (year: number, month: number) => {
  return new Date(year, month, 0).getDate();
}
export const getMonthName = (month: number, locale: string): string => {
    const d = new Date();
    d.setMonth(month);
    return d.toLocaleString(locale, {month: 'long'});
}
export const getCurrentMonth = (): number => new Date().getMonth() + 1;
export const getCurrentYear = (): number => new Date().getFullYear();