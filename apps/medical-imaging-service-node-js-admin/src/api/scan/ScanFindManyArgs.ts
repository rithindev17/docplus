import { ScanWhereInput } from "./ScanWhereInput";
import { ScanOrderByInput } from "./ScanOrderByInput";

export type ScanFindManyArgs = {
  where?: ScanWhereInput;
  orderBy?: Array<ScanOrderByInput>;
  skip?: number;
  take?: number;
};
