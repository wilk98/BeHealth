import React, { useEffect, useState } from 'react'
import './Carousel.css'


const Carousel = (props: { children: any , show: any}) => {

    const {children, show} = props
    const [currentIndex, setCurrentIndex] = useState(0)
    const [length, setLength] = useState(children.length)
    console.log(show);

    useEffect(() => {
        setLength(children.length)
    }, [children])

    const next = () => {
        if (currentIndex < (length - show)) {
            setCurrentIndex(prevState => prevState + 1)
        }
    }
    
    const prev = () => {
        if (currentIndex > 0) {
            setCurrentIndex(prevState => prevState - 1)
        }
    }
    
    return (
        <div className="carousel-container">
            <div className="carousel-wrapper">
                {
                    currentIndex > 0 &&
                    <button onClick={prev} className="left-arrow">
                        &lt;
                    </button>
                }
                <div className="carousel-content-wrapper">
                    <div className={`carousel-content`} style={{ transform: `translateX(-${currentIndex * (100/show)}%)` }}>
                        {children}
                    </div>
                </div>
                {
                    currentIndex < (length - show) &&
                    <button onClick={next} className="right-arrow">
                        &gt;
                    </button>
                }
            </div>
        </div>
    )
}



export default Carousel
