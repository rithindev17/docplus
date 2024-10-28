import { Scan as TScan } from "../api/scan/Scan";

export const SCAN_TITLE_FIELD = "id";

export const ScanTitle = (record: TScan): string => {
  return record.id?.toString() || String(record.id);
};
