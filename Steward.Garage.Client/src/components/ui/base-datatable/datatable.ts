/* eslint-disable @typescript-eslint/indent */
import type { Component } from 'vue';

export type TUnitPixels = `${number}px`;
export type TUnitPercent = `${number}%`;
export type TUnitVH = `${number}vh`;
export type TUnitVW = `${number}vw`;
export type TData = Record<string, any>;

export interface TDatatableDataLocalOption {
  type: 'local';
  source: any[] | TData[];
}

export interface TDatatableDataRemoteOption {
  type: 'remote';
  source: {
    url: string;
    method?: 'GET' | 'POST';
    params?: Record<string, any>;
    uniqueKey?: any;
    pagingMap: (page: number, perPage: number) => Record<string, any>;
    mapApiReponse: (rawData: any) => {
      data: any[];
      pagination: { page: number; total: number; perPage: number };
    };
  };
}

export interface TDatatableLayoutOption {
  cellWidth?: TUnitPixels;
  height?: TUnitPixels | TUnitPercent | TUnitVH;
  minHeight?: TUnitPixels | TUnitPercent | TUnitVH;
  header?: boolean;
  footer?: boolean;
  icons?: {
    sort?:
      | {
          asc?: string | never;
          desc?: string | never;
        }
      | never;
    pagination?:
      | {
          next?: string | never;
          prev?: string | never;
          first?: string | never;
          last?: string | never;
        }
      | never;
    rowDetail?:
      | {
          expand?: string | never;
          collapse?: string | never;
        }
      | never;
  };
  pagination?:
    | {
        pageSize?: number | never;
        pageButtonsNumber?: number | never;
      }
    | never;
}

export type TColumnTemplate = (rowData: any) => Component;

export interface TDatatableColumnItem {
  field: string;
  title: string;
  width?: TUnitPixels | never;
  textAlign?: 'center' | 'left' | 'right' | never;
  template?: TColumnTemplate | never | ((row: any) => string);
  templateHeader?: TColumnTemplate | never;
  templateFoot?: TColumnTemplate | never;
  lock?: 'left' | 'right';
}

export interface TDatatableOptions {
  data: TDatatableDataLocalOption | TDatatableDataRemoteOption;
  pagination?: boolean;
  scrollable?: boolean;
  layout?: TDatatableLayoutOption | never;
  columns: TDatatableColumnItem[];
  textPlaceholder?:
    | {
        noRecords?: string;
        pagination?:
          | {
              first?: string | never;
              prev?: string | never;
              next?: string | never;
              last?: string | never;
              select?: string | never;
            }
          | never;
        pageInfo?: string | never;
      }
    | never;
}
