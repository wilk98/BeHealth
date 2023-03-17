import React, { useState, useEffect, useContext } from 'react';
import { api_path } from '../utils/api';
import { useParams } from 'react-router-dom';
import { BeHealthContext } from '../Context';

interface VisitData {
  day: string;
  startHour: string;
  endHour: string;
}

interface FormData {
  day: string;
  startHour: string;
  visitType: string;
}

const ArrangeVisit: React.FC = () => {
  const [visits, setVisits] = useState<VisitData[]>([]);
  const [selectedDay, setSelectedDay] = useState('');
  const [availableHours, setAvailableHours] = useState<string[]>([]);
  const [selectedHour, setSelectedHour] = useState('');
  const [visitTypes, setVisitTypes] = useState<string[]>([]);
  const { doctorId } = useParams<{ doctorId: string }>();
  const { token, user } = useContext(BeHealthContext)

  const [selectedVisitType, setSelectedVisitType] = useState('');
  
  const [formData, setFormData] = useState<FormData>({
    day: '',
    startHour: '',
    visitType: '',
  });

  useEffect(() => {
    const fetchData = async () => {
      const response = await fetch(`${api_path}/api/workhours/${doctorId}`);
      const data = await response.json();
      setVisits(data);
    };
    fetchData();
  }, []);

  useEffect(() => {
    if (selectedDay) {
      const selectedVisit = visits.find((visit) => visit.day === selectedDay);
      if (selectedVisit) {
        const hours = generateAvailableHours(selectedVisit.startHour, selectedVisit.endHour);
        setAvailableHours(hours);
      } else {
        setAvailableHours([]);
      }
      setSelectedHour('');
    }
  }, [selectedDay, visits]);

  useEffect(() => {
    if (selectedHour) {
      const fetchData = async () => {
        const response = await fetch(`${api_path}/api/visitTypes`);
        const data = await response.json();
        setVisitTypes(data);
      };
      fetchData();
    } else {
      //setVisitTypes([]);
	  setVisitTypes(['Konsultacja lekarska']);
    }
  }, [selectedHour]);

  const generateAvailableHours = (startHour: string, endHour: string) => {
    const availableHours: string[] = [];
    const start = new Date(`01/01/2000 ${startHour}`);
    const end = new Date(`01/01/2000 ${endHour}`);
    let current = start;
    while (current < end) {
      availableHours.push(current.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }));
      current = new Date(current.getTime() + 15 * 60000);
    }
    return availableHours;
  };

  const dataTimeString = `${selectedDay} ${selectedHour}:00`;

  const handleFormSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
  
    if (!selectedVisitType) {
      console.error('Please select a visit type');
      return;
    }
    if (user?.id && doctorId){
    const visitData = {
      name: selectedVisitType,
      patientId: parseInt(user.id),
      doctorId: parseInt(doctorId),
      visitDate: new Date(dataTimeString),
      duration: 15,
    };
  
    console.log(visitData);
  
      const response = await fetch(`${api_path}/api/visits`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(visitData)
      });
      if (response.ok) {
  
        setFormData({
      day: '',
      startHour: '',
      visitType: '',
    });
    setSelectedDay('');
    setSelectedHour('');
    setSelectedVisitType('');
  }}};

  return (
    <div>
      <h1>Umów wizytę</h1>
      <form onSubmit={handleFormSubmit}>
        <label htmlFor="day">Wybierz dzień</label>
        <select
          name="day"
          id="day"
          value={selectedDay}
          onChange={(event) => setSelectedDay(event.target.value)}
        >
          <option value=""></option>
          {visits.map((visit) => (
            <option key={visit.day} value={visit.day}>
              {visit.day}
            </option>
          ))}
        </select>

        <label htmlFor="hour">Wybierz godzinę</label>
		<select
      name="hour"
      id="hour"
      value={selectedHour}
      onChange={(event) => setSelectedHour(event.target.value)}
      disabled={!selectedDay}
    >
      <option value=""></option>
      {availableHours.map((hour) => (
        <option key={hour} value={hour}>
          {hour}
        </option>
      ))}
    </select>

    <label htmlFor="visitType">Wybierz rodzaj wizyt</label>
    <select
      name="visitType"
      id="visitType"
      value={selectedVisitType}
      onChange={(event) => setSelectedVisitType(event.target.value)}
      disabled={!selectedHour}
    >
      <option value=""></option>
      {visitTypes.map((visitType) => (
        <option key={visitType} value={visitType}>
          {visitType}
        </option>
      ))}
    </select><br></br>

    <button type="submit" disabled={!selectedVisitType}>
      Potwierdź
    </button>
  </form>
</div>
)};

export default ArrangeVisit;
