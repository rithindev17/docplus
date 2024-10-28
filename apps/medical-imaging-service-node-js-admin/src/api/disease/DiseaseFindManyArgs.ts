import { DiseaseWhereInput } from "./DiseaseWhereInput";
import { DiseaseOrderByInput } from "./DiseaseOrderByInput";

export type DiseaseFindManyArgs = {
  where?: DiseaseWhereInput;
  orderBy?: Array<DiseaseOrderByInput>;
  skip?: number;
  take?: number;
};
