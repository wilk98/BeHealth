import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import "./DoctorProfileForUser.css";
import { api_path } from '../utils/api';
import doctorImage from "../assets/images/doctorExample.png"
import axios from "axios";

enum ProfileSection {
  Experience,
  PriceList,
  Opinion,
}


interface Doctor {
  id: string;
  specialist: string,
  firstName: string,
  lastName: string
  phone: string;
  email: string;
  imageUrl: string;
}

export const DoctorProfile: React.FC = () => {
  const { doctorId } = useParams<{ doctorId: string }>();
  const [selectedSection, setSelectedSection] = useState(ProfileSection.Experience);
  const [doctor, setDoctor] = useState<Doctor | null>(null);

  useEffect(() => {
    const fetchDoctor = async () => {
      try {
        const response = await fetch(`${api_path}/api/doctors/${doctorId}`);
        const data = await response.json();
        setDoctor(data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchDoctor();
  }, [doctorId]);

  const handleTabClick = (section: ProfileSection) => {
    setSelectedSection(section);
  };

  if (!doctor) {
    return <div>Brak danych</div>;
  }

  const handleVisitClick = (doctorId:string) => {
  }

  const { id, firstName, lastName, specialist, phone, email } = doctor;

  return (
    <div className="doctor-profile">
      <div className="doctor-info">
        <img src={doctorImage} alt={`${firstName} ${lastName}'s profile picture`} />
        <h2>{firstName} {lastName}</h2><br></br>
        <p>Specjalizacja</p>
        <h3>{specialist}</h3><br></br>
        <p>Numer telefonu</p>
        <h3>{phone}</h3><br></br>
        <p>Adres e-mail</p>
        <h3>{email}</h3><br></br>
        <button onClick={() => handleVisitClick(id)}>Umów wizytę</button>
      </div>
      <div className="doctor-details">
        <ul className="doctor-tabs">
          <li
            className={selectedSection === ProfileSection.Experience ? 'active' : ''}
            onClick={() => handleTabClick(ProfileSection.Experience)}
          >
            Doświadczenie
          </li>
          <li
            className={selectedSection === ProfileSection.PriceList ? 'active' : ''}
            onClick={() => handleTabClick(ProfileSection.PriceList)}
          >
            Cennik
          </li>
          <li
            className={selectedSection === ProfileSection.Opinion ? 'active' : ''}
            onClick={() => handleTabClick(ProfileSection.Opinion)}
          >
            Opinie
          </li>
        </ul>
        <div className="doctor-details-content">
          {selectedSection === ProfileSection.Experience && (
            <div>
              <h3></h3>
              <p>{specialist}</p>
              <p></p>
              <p></p>
            </div>
          )}
          {selectedSection === ProfileSection.PriceList && (
            <div>
              <h3></h3>
              <p></p>
              <p>100zł</p>
            </div>
          )}
          {selectedSection === ProfileSection.Opinion && (
            <div>
              <h3></h3>
              <p></p>
              <p></p>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};
