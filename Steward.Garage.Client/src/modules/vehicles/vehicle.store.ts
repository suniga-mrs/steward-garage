import { defineStore } from 'pinia';
import type { IVehicleProfile } from './types';
import type { IAppApiResponse } from '../../ts/api-response';

export const useVehicleStore = defineStore({
  id: 'vehicle',
  state: () => ({
    vehicle: null as IVehicleProfile | null,
    isFetchingVehicle: true,
  }),
  getters: {
    currentVehicle: (state) => state.vehicle,
  },
  actions: {
    init: async function(plateNo: string) {
      await this.setVehicle({ plateNo });
    },
    setVehicle(param: {plateNo?: string, vehicleId?: string}) : any{
      //@ts-expect-error - TODO: type pinia plugin for http client
      return this.httpClient
        ?.get({
          url: '/api/vehicles/profile',
          data: {
            plateNo: param?.plateNo ?? '',
            vehicleId: param?.vehicleId ?? 0,
          }
        })
        .then((result: IAppApiResponse<IVehicleProfile>) => {
          
          if (result.data) {
            this.vehicle = result.data;
          }

          this.isFetchingVehicle = false;

        });
    },
    
  },
});
