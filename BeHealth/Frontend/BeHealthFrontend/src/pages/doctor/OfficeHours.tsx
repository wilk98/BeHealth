import React, { useState, useEffect, useContext } from "react";
import { BeHealthContext } from "../../Context";
import { api_path } from '../../utils/api';


interface WorkHours {
  day: string;
  startHour: string;
  endHour: string;
}

const OfficeHours: React.FC = () => {
  const [workHoursList, setWorkHoursList] = useState<WorkHours[]>([]);
  const [selectedDay, setSelectedDay] = useState("");
  const [selectedStartHour, setSelectedStartHour] = useState("");
  const [selectedEndHour, setSelectedEndHour] = useState("");
  const [availableDays, setAvailableDays] = useState<string[]>([]);
  const [availableHours, setAvailableHours] = useState<string[]>([]);
  const { token, user } = useContext(BeHealthContext)
  const doctorId = user?.id;

  useEffect(() => {
    // Pobierz godziny pracy z bazy danych
    const fetchWorkHours = async () => {
      const response = await fetch(`${api_path}/api/workhours/${doctorId}`);
      const workHoursList = await response.json();
      setWorkHoursList(workHoursList);
    };

    fetchWorkHours();

    // Wygeneruj listę dostępnych dni
    const today = new Date();
    const days = [];
    for (let i = 0; i < 30; i++) {
      const date = new Date(today.getTime() + i * 24 * 60 * 60 * 1000);
      const dateString = date.toISOString().split("T")[0];
      days.push(dateString);
    }
    setAvailableDays(days);

    // Wygeneruj listę dostępnych godzin
    const hours = [];
    for (let hour = 0; hour < 24; hour++) {
      for (let minute = 0; minute < 60; minute += 15) {
        const timeString = `${hour.toString().padStart(2, "0")}:${minute
          .toString()
          .padStart(2, "0")}`;
        hours.push(timeString);
      }
    }
    setAvailableHours(hours);
  }, []);

  const handleAddWorkHours = async () => {
    // Dodaj godziny pracy do bazy danych
    const response = await fetch(`${api_path}/api/workhours`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        doctorId: doctorId,
        day: selectedDay,
        startHour: selectedStartHour,
        endHour: selectedEndHour,
      }),
    });

    if (response.ok) {
      const workHours = await response.json();
      setWorkHoursList([...workHoursList, workHours]);
      setSelectedDay("");
      setSelectedStartHour("");
      setSelectedEndHour("");
    }
  };

  const generateTimeOptions = (startHour: number, endHour: number) => {
    const options = [];
    for (let hour = startHour; hour <= endHour; hour++) {
      for (let minute = 0; minute < 60; minute += 15) {
        const timeString = `${hour.toString().padStart(2, "0")}:${minute
          .toString()
          .padStart(2, "0")}`;
        options.push(
          <option key={timeString} value={timeString}>
            {timeString}
          </option>
        );
      }
    }
    return options;
  };

  return (
    <div>
      <h1>Godziny pracy</h1>
      <div>
      <label htmlFor="day">Dzień:</label>
    <select
      id="day"
      value={selectedDay}
      onChange={(e) => setSelectedDay(e.target.value)}
    >
      <option value="">-- wybierz dzień --</option>
      {availableDays.map((day) => (
        <option key={day} value={day}>
          {day}
        </option>
      ))}
    </select>
  </div>
  <div>
    <label htmlFor="start-hour">Godzina początkowa:</label>
    <select
      id="start-hour"
      value={selectedStartHour}
      onChange={(e) => setSelectedStartHour(e.target.value)}
    >
      {generateTimeOptions(0, 23)}
    </select>
  </div>
  <div>
    <label htmlFor="end-hour">Godzina końcowa:</label>
    <select
      id="end-hour"
      value={selectedEndHour}
      onChange={(e) => setSelectedEndHour(e.target.value)}
    >
      {generateTimeOptions(0, 23)}
    </select>
  </div>
  <button onClick={handleAddWorkHours}>Dodaj godziny pracy</button>
  <h2>Lista godzin pracy:</h2>
  {workHoursList.map((workHours) => (
    <div key={workHours.day}>
      <h3>{workHours.day}</h3>
      <p>{workHours.startHour} - {workHours.endHour}</p>
    </div>
  ))}
</div>
  );};

  export default OfficeHours;



