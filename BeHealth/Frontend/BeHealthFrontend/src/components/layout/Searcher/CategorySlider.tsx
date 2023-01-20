import '@splidejs/splide/css';
import { Splide, SplideSlide } from '@splidejs/react-splide';
import React from 'react';

function CategorySlider() {
	return (
        <Splide
          options={ {
            rewind: true,
            gap   : '1rem',
          } }
          aria-label="My Favorite Images"
        >
          <SplideSlide>
            <img src="" alt="Image 1"/>
          </SplideSlide>
          <SplideSlide>
            <img src="" alt="Image 2"/>
          </SplideSlide>
          <SplideSlide>
            <img src="" alt="Image 3"/>
          </SplideSlide>
        </Splide>
      );
    }

export default CategorySlider;