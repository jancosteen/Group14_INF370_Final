import {Special } from '../Special/special.model';

      export interface SpecialPrice {
          specialPriceId: number;
          specialPrice: string;
          specialPriceDateUpdate: Date;
          special:Special;
      }